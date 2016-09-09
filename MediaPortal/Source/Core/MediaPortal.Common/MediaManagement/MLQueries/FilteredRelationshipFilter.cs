#region Copyright (C) 2007-2014 Team MediaPortal

/*
    Copyright (C) 2007-2014 Team MediaPortal
    http://www.team-mediaportal.com

    This file is part of MediaPortal 2

    MediaPortal 2 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal 2 is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal 2. If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using System;
using System.Xml.Serialization;

namespace MediaPortal.Common.MediaManagement.MLQueries
{
  /// <summary>
  /// Filter which filters based on the relationship
  /// </summary>
  public class FilteredRelationshipFilter : IFilter
  {
    protected IFilter _linkedFilter;
    protected Guid _role;
    protected Guid _linkedRole;

    public FilteredRelationshipFilter(Guid role, Guid linkedRole, IFilter linkedFilter)
    {
      _linkedFilter = linkedFilter;
      _role = role;
      _linkedRole = linkedRole;
    }

    [XmlIgnore]
    public IFilter LinkedFilter
    {
      get { return _linkedFilter; }
      set { _linkedFilter = value; }
    }

    [XmlIgnore]
    public Guid Role
    {
      get { return _role; }
      set { _role = value; }
    }

    [XmlIgnore]
    public Guid LinkedRole
    {
      get { return _linkedRole; }
      set { _linkedRole = value; }
    }

    public override string ToString()
    {
      return "(ITEM_ID IN (" + _linkedFilter + ")" + (_role != Guid.Empty ? " AND ROLE='" + _role + "'" : "") + " AND LINKED_ROLE='" + _linkedRole + "')";
    }

    #region Additional members for the XML serialization

    internal FilteredRelationshipFilter() { }

    /// <summary>
    /// For internal use of the XML serialization system only.
    /// </summary>
    [XmlElement("Between", typeof(BetweenFilter))]
    [XmlElement("BooleanCombination", typeof(BooleanCombinationFilter))]
    [XmlElement("In", typeof(InFilter))]
    [XmlElement("Like", typeof(LikeFilter))]
    [XmlElement("Not", typeof(NotFilter))]
    [XmlElement("Relational", typeof(RelationalFilter))]
    [XmlElement("Empty", typeof(EmptyFilter))]
    [XmlElement("RelationalUserData", typeof(RelationalUserDataFilter))]
    [XmlElement("EmptyUserData", typeof(EmptyUserDataFilter))]
    [XmlElement("False", typeof(FalseFilter))]
    [XmlElement("MediaItemIds", typeof(MediaItemIdFilter))]
    [XmlElement("Relationship", typeof(RelationshipFilter))]
    [XmlElement("FilteredRelationship", typeof(FilteredRelationshipFilter))]
    public object XML_Filter
    {
      get { return _linkedFilter; }
      set { _linkedFilter = value as IFilter; }
    }

    /// <summary>
    /// For internal use of the XML serialization system only.
    /// </summary>
    [XmlAttribute("Role")]
    public Guid XML_Role
    {
      get { return _role; }
      set { _role = value; }
    }

    /// <summary>
    /// For internal use of the XML serialization system only.
    /// </summary>
    [XmlAttribute("LinkedRole")]
    public Guid XML_LinkedRole
    {
      get { return _linkedRole; }
      set { _linkedRole = value; }
    }

    #endregion
  }
}
